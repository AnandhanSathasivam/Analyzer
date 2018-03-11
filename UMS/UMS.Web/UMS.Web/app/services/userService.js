app.service('userService', ['$http', function ($http) {
    var BaseUrl = 'http://localhost:51191/api/user';

    this.save = function (user) {
        var request = $http({
            method: "post",
            url: BaseUrl + "/",
            data: user,
            datatype: 'json',
            headers: {
                "Content-Type": "application/json"
            }
        });
        return request;
    }
    this.delete = function (id) {
        var request = $http({
            method: "delete",
            url: BaseUrl + "/" + id,
            dataType: 'json',
            headers: {
                "Content-Type": "application/json"
            }
        });
        return request;
    }
    this.update = function (user)
    {
        var request = $http({
            method: "put",
            url: BaseUrl + "/",
            data: user,
            datatype: 'json',
            headers: {
                "Content-Type": "application/json"
            }
        });
        return request;

        //alert(user.userid);
        //$http.put(BaseUrl + "/" + user.userid, user);
    }
    this.userList = function () {
        return $http.get(BaseUrl);
    }
    this.get = function (id) {
        return $http.get(BaseUrl + "/" + id);
    }
}]);