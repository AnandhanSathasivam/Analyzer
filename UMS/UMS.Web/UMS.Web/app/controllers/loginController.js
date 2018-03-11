app.controller('loginController', function ($scope, $rootScope) {
    $rootScope.currentPage = 'Login';
    $scope.submitForm = function () {
        $scope.submitted = true;
        if ($scope.userForm.$valid) {

        }
        else { }
    }
});