app.controller('formUsercontroller', function ($scope, $route, $rootScope, $routeParams, userService) {
    $rootScope.currentPage = "Add User";
    $scope.submitForm = function () {
        $scope.submitted = true;
        if ($scope.userForm.$valid) {
            var btntext = $("#btnsubmit").text();
            if (btntext == "Submit") {
                userService.save($scope.newUser).success(function (data) {
                    bootbox.alert({
                        size: 'small',
                        message: "Saved successfully",
                        callback: function () {
                            window.location.href = 'Base.html#/viewuser';
                            $scope.newUser = {};
                        }
                    });
                });
            }
            else {
                userService.update($scope.newUser).success(function (data) {
                    bootbox.alert({
                        size: 'small',
                        message: "Updated successfully",
                        callback: function () {
                            window.location.href = 'Base.html#/viewuser';
                            $scope.newUser = {};
                        }
                    });
                });
            }
        }
        else {

        }
    };
    var current = $route.current.currentpage;
    if (current == 'edituser') {
        $scope.newUser = userService.get($routeParams.id).success(function (data) {
            $scope.newUser = data;
            $("#btnsubmit").text("Update");
        });
    }
    ////---------------OR----------
    //if ($routeParams.id != undefined) {
    //    $scope.newUser = userService.get($routeParams.id).success(function (data) {
    //        $scope.newUser = data;
    //        $("#btnsubmit").text("Update");
    //    });
    //}

    $scope.preferredlanguages = [{
        Id: 1,
        Name: 'Tamil',
        Selected: false
    },
   {
       Id: 2,
       Name: 'English',
       Selected: false
   }];

});