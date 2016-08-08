using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Jobs
{
    static class NativeJob
    {
        [DllImport("kernel32")]
        public static extern IntPtr CreateJobObject(IntPtr sa, string name);

        [DllImport("kernel32", SetLastError = true)]
        public static extern bool AssignProcessToJobObject(IntPtr hjob, IntPtr hprocess);

        [DllImport("kernel32")]
        public static extern bool CloseHandle(IntPtr h);

        [DllImport("kernel32")]
        public static extern bool TerminateJobObject(IntPtr hjob, uint code);
    }

    public class Job : IDisposable
    {
        private IntPtr _hJob;
        private List<Process> _processes;
        private bool _disposed = false;
        private long sizeInByte = 0;

        public Job(string name/*, long _sizeInByte*/)
        {
            _hJob = NativeJob.CreateJobObject(IntPtr.Zero, name);
            if (_hJob == IntPtr.Zero)
                throw new InvalidOperationException();
            _processes = new List<Process>();
        /*    sizeInByte = _sizeInByte;
            GC.AddMemoryPressure(sizeInByte);*/
        }

        public Job()
            : this(null)
        {
        }

        protected void AddProcessToJob(IntPtr hProcess)
        {
            CheckIfDisposed();

            if (!NativeJob.AssignProcessToJobObject(_hJob, hProcess))
                throw new InvalidOperationException("Failed to add process to job");
        }

        private void CheckIfDisposed()
        {
            // מה לשלוח פה בתור שם? להגיע לשם שקיבלנו בקוסנטרקטור?
            if ( _disposed) throw new ObjectDisposedException(this.ToString());
        }

        public void AddProcessToJob(int pid)
        {
            AddProcessToJob(Process.GetProcessById(pid));
        }

        public void AddProcessToJob(Process proc)
        {
            Debug.Assert(proc != null);
            AddProcessToJob(proc.Handle);
            _processes.Add(proc);
        }
        
        public void Kill()
        {
            // what is this code?
            NativeJob.TerminateJobObject(_hJob, 0);
        }

        public void Dispose()
        { // from IDisposable
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~Job() { Dispose(false); }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                // אין דיספוז לרשימה. האם צריך לעשות משהו בכלל?
                _processes = null;
            }
            // ככה משחררים את האובייקט הזה?
            NativeJob.CloseHandle(_hJob);
            GC.RemoveMemoryPressure(sizeInByte);
            _disposed = true;
        }

    }
}
