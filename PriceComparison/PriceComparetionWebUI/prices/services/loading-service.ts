namespace PriceComparison {

    export interface ILoadingService {
        loading(action: ng.IPromise<any>): ng.IPromise<any>;
        register(name: string, callback: Function): void;
    }

    export class Observer {
        name: string;
        callback: Function;

        constructor(n: string, callback: Function) {
            this.name = n;
            this.callback = callback;
        }
    }

    export class LoadingService implements ILoadingService{
        counter: number= 0;
        observers: Observer[]= [];

        constructor(private $q: ng.IQService) {
            
        }

        register(name: string, callback: Function) {
            this.observers.push(new Observer(name, callback));
        }

        loading<T>(action: ng.IPromise<T>): ng.IPromise<T> {
            var defferd = this.$q.defer<T>();

            this.loadingStart();

            action.then((data) => defferd.resolve(data)
                , () => defferd.reject())
                .finally(() => this.loadingDone());

            return defferd.promise;
        }
        loadingStart() {
            this.counter++;
            if (this.counter === 1) {
                for (var observer of this.observers) {
                    observer.callback(true);
                }
            }
        }

        loadingDone() {
            this.counter--;
            if (this.counter === 0) {
                for (var observer of this.observers) {
                    observer.callback(false);
                }
            }
        }
    }

    app.service("loadingService", LoadingService);

}