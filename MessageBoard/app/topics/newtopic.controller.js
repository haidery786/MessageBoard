
(function () {

    angular.module('topics.module')
        .controller('NewTopicController', ['$scope', 'topicsFactory', '$window', function ($scope, topicsFactory , $window) {

            $scope.newTopic = {};         

            // Save Application Event
            $scope.save = function () {
              
                var newTopic = this.newTopic;
                topicsFactory.addTopic(newTopic)
                .then(function () {
                    //Success
                    $window.location = "#/";
                },
                function () {
                    //Error
                    alert("An Error has occurred while adding new topic!");
                })
                .then(function () {
                    $scope.isBusy = false;

                });
               
            };


        }]);
})();