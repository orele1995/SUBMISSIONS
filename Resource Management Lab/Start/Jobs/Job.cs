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
        private long _sizeInByte = 0;
        private string _name;

        public Job(string name, long sizeInByte)
        {
           
            _name = name;

            _hJob = NativeJob.CreateJobObject(IntPtr.Zero, name);
            if (_hJob == IntPtr.Zero)
                throw new InvalidOperationException();
            if (sizeInByte <= 0)
                throw new ArgumentException("you can't send a size that is smaller then 1");
            GC.AddMemoryPressure(sizeInByte);
            _sizeInByte = sizeInByte;
            _processes = new List<Process>();
            
        }

        public Job()
            : this(null,1)
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
            if ( _disposed) throw new ObjectDisposedException(_name);
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
            NativeJob.TerminateJobObject(_hJob, 0);
        }

        public void Dispose()
        { 
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~Job() { Dispose(false); }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                foreach (var process in _processes)
                {
                    process.Dispose();
                }
                _processes = null;
            }
            NativeJob.CloseHandle(_hJob);
            GC.RemoveMemoryPressure(_sizeInByte);
            _disposed = true;
        }

    }
}
