(function () {

    angular.module('topics.module')
    .controller('TopicsController', ['$scope', 'topicsFactory', function ($scope, topicsFactory) {
        $scope.isBusy = false;
        $scope.DataCount = 0;

        $scope.data = topicsFactory;

       // console.log(topicsFactory.isReady());

        if (topicsFactory.isReady() == false) {
            $scope.isBusy = true;
            topicsFactory.gettopics()
            .then(function () {
                //Success
            },
            function () {
                //Error
                alert("An Error has occurred while loading topics!");
            })
            .then(function () {
                $scope.isBusy = false;

            });
        }




        //topicsFactory.gettopics().success(function (data) {
        //    console.log(data);
        //    $scope.topics = data;
        //})
        // .error(function (data) {
        //     $scope.error = "An Error has occurred while loading topics! " + data.ExceptionMessage;
        // })
        // .then(function () {
        //     $scope.isBusy = false;

        // })
        //;


        //$scope.loading = true;
        //$scope.addMode = false;

        //$scope.toggleEdit = function () {

        //    this.application.editMode = !this.application.editMode;

        //  //  $scope.getOrigionalApp();
           
        //};

        //$scope.toggleEditOnCancell = function () {
        //   // var tempApplication = angular.copy(application);

        //    this.application.editMode = !this.application.editMode;

        //     $scope.getOrigionalApp();

        //};
       
        //$scope.toggleAdd = function () {
        //    $scope.addMode = !$scope.addMode;
        //};


        //// Save Application Event
        //$scope.save = function () {
        //    $scope.loading = true;
        //    var appl = this.application;
        //    applicationFactory.updateApplication(appl).success(function (data) {
        //        alert("Saved Successfully!!");
        //        appl.editMode = false;
        //        $scope.loading = false;
        //    }).error(function (data) {
        //        $scope.error = "An Error has occurred while Saving application! " + data.ExceptionMessage;
        //        $scope.loading = false;

        //    });
        //};

        //// add Application Event
        //$scope.add = function () {
        //    $scope.loading = true;
        //    applicationFactory.addApplication(this.newapplication).success(function (data) {
        //        alert("Added Successfully!!");
        //        $scope.addMode = false;
        //        $scope.applications.push(data);
        //        $scope.loading = false;
        //    }).error(function (data) {
        //        $scope.error = "An Error has occurred while Adding application! " + data.ExceptionMessage;
        //        $scope.loading = false;

        //    });
        //};
        //// delete Application Event
        //$scope.delapplication = function () {
        //    $scope.loading = true;
        //    var currApp = this.application;
        //    applicationFactory.deleteApplication(currApp).success(function (data) {
        //        alert("Deleted Successfully!!");
        //        $.each($scope.applications, function (i) {
        //            if ($scope.applications[i].ID === currApp.ID) {
        //                $scope.applications.splice(i, 1);
        //                return false;
        //            }
        //        });
        //        $scope.loading = false;
        //    }).error(function (data) {
        //        $scope.error = "An Error has occurred while deleting application! " + data.ExceptionMessage;
        //        $scope.loading = false;

        //    });
        //};

        //// get Application Event
        //$scope.getOrigionalApp = function () {
        //    applicationFactory.getApplication().success(function (data) {
        //        console.log(data);
        //        $scope.applications = data;
        //    })
        // .error(function (data) {
        //     $scope.error = "An Error has occurred while loading posts! " + data.ExceptionMessage;
        // });
        //};

        //$scope.getAllApplications = function () {
        //    console.log('getAllApplications called');
        //    applicationFactory.getApplication().success(function (data) {
        //        console.log(data);
        //        $scope.applications = data;
        //        $scope.loading = false;
        //    })
        //    .error(function (data) {
        //        $scope.error = "An Error has occurred while loading posts! " + data.ExceptionMessage;
        //        $scope.loading = false;
        //    });

        //};

        //get all Topics including replies - Self Calling -On load

      

    
    }]);
})();