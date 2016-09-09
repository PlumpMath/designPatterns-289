angular.module('designPatterns.Services').factory('adminService', function ($httpq) {

    return {
        BridgePattern: function (customSource) {
            return $httpq.get("/testBridgePattern/" + customSource);
        },
        ObserverPattern: function() {
            return $httpq.get("/testObserverPattern");
        },
        TestStatePattern: function() {
            return $httpq.get("/testStatePattern");
        },
        TestNullObjectPattern: function () {
            return $httpq.get("/testNullObjectPattern");
        },
        GetUsers: function (payload) {
            return $httpq.get("/users?" + "PageNumber=" + payload.PageNumber + "&PageSize=" + payload.PageSize + "&Field=" + payload.Field);
        },
        EnableUser: function (payload) {
            return $httpq.post("/users/enable", payload);
        },
        GetUser: function(id) {
            return $httpq.get("/user/" + id );
        },
        UpdateProfile: function(payload) {
            return $httpq.post("/user/", payload);
        },
        GetRol:function() {
            return $httpq.get("/rol");
        }
        
    };
});