
(function () {

    angular.module('topics.module')
        .controller('SingleTopicController', ['$scope', 'topicsFactory', '$window' ,'$routeParams' , function ($scope, topicsFactory , $window , $routeParams) {

            $scope.topic = null;
            $scope.newReply = {};

            topicsFactory.getTopicById($routeParams.id)
              .then(function (topic) {
                  //Success
                  $scope.topic = topic;
              },
              function () {
                  //Error
                $window.location = "#/";             
              });

            $scope.addReply = function () {

                var newReply = this.newReply;
                topicsFactory.saveReply($scope.topic, newReply)
                .then(function(){
                    //success
                    $scope.newReply.body = "";
                },
                function(){
                    //reply
                    aler("Could not save the new reply");
                });
            };           


        }]);
})();