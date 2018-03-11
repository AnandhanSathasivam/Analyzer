app.controller('userListcontroller', function ($scope, $rootScope, $routeParams, $route, userService) {
    //$scope.message = "this is user " + $routeParams.id + " list controller";

    $scope.users = [];
    userService.userList().success(function (data) {
        $scope.users = data;
    });
    var current = $route.current.currentpage;
    if (current == 'deleteuser') {
        bootbox.confirm("Are you sure?", function (result) {
            if (result == true) {
                userService.delete($routeParams.id).success(function (data) {
                    window.location.href = 'Base.html#/viewuser';
                });
            }
        });
    }
    $rootScope.currentPage = "View Users";
});