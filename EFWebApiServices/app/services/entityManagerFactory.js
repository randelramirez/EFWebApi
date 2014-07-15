(function () {
    'use strict';

    var serviceId = 'entityManagerFactory';
    angular.module('app').factory(serviceId, ['config', emFactory]);

    function emFactory(config) {
        return {
            newManager: newManager
        }
        function newManager() {
            var mgr = new breeze.EntityManager(config.remoteServiceName);
            return mgr;
        }

    }
})();


