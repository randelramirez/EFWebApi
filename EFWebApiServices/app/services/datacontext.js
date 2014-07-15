(function () {
    'use strict';

    var serviceId = 'datacontext';
    angular.module('app').factory(serviceId, ['common', 'entityManagerFactory', datacontext]);

    function datacontext(common, entityManagerFactory) {
        var $q = common.$q;
        var manager = entityManagerFactory.newManager();

        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(serviceId);
        var logError = getLogFn(serviceId, 'error');
        var logSuccess = getLogFn(serviceId, 'success');
        var service = {
            createOrder: createOrder,
            getBooks: getBooks,
            getPeople: getPeople,
            getMessageCount: getMessageCount,
            ready: getReady
        };

        return service;
        function addBookToOrder(book, order) {
           var detail = manager.createEntity("OrderDetail", {
                book: book,
                order: order,
                quantity: 1
           });

           return detail;
        }

        function createOrder() {
            manager.createEntity("Order", {
                orderDate: new Date().toUTCString()
            });
            return order;
        }

        function getMessageCount() { return $q.when(72); }

        function getPeople() {
            var people = [
                { firstName: 'John', lastName: 'Papa', age: 25, location: 'Florida' },
                { firstName: 'Ward', lastName: 'Bell', age: 31, location: 'California' },
                { firstName: 'Colleen', lastName: 'Jones', age: 21, location: 'New York' },
                { firstName: 'Madelyn', lastName: 'Green', age: 18, location: 'North Dakota' },
                { firstName: 'Ella', lastName: 'Jobs', age: 18, location: 'South Dakota' },
                { firstName: 'Landon', lastName: 'Gates', age: 11, location: 'South Carolina' },
                { firstName: 'Haley', lastName: 'Guthrie', age: 35, location: 'Wyoming' }
            ];
            return $q.when(people);
        }

        function getReady() {
            return manager.metadataStore.fetch(manager.dataService)
                .then(function () {
                    logSuccess("Metadata fetched")
                })
                .catch(function (error) {
                    logError("Metadata fetch failed!" + error.message, error, true)
                    return $q.reject(error);
                });
        }

        function getBooks() {
            return breeze.EntityQuery.from('Books')
                .using(manager)
                .execute()
                .then(success)
                .catch(fail)

            function success(resp) {
                var book = resp.results;
                logSuccess("Yay! We got books " + book.length, null, true);
                return book;
            };

            function fail(error) {
                logError('oops we got' + error.message, error, true);
            }
        }
    }
})();