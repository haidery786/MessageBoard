(function () {
    'use strict';

   
    angular.module('app',
        [
          'ngRoute',
          'topics.module'
        ])
        .config(function ( $routeProvider) {
        $routeProvider
            .when('/',
                {
                  controller: 'TopicsController',
                  templateUrl: "/app/topics/templates/topics.html"
                })
            .when('/topics',
                {
                    controller: 'TopicsController',
                    templateUrl: "/app/topics/templates/topics.html"
                })
            .when('/newtopic',
            {
                controller: 'NewTopicController',
                templateUrl: "/app/topics/templates/newTopicView.html"

            })
              .when('/message/:id',
            {
                controller: 'SingleTopicController',
                templateUrl: "/app/topics/templates/singleTopicView.html"

            })
            .otherwise({ redirectTo: '/' });

    });      
   
})();