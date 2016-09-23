angular.module('designPatterns.Controllers').controller('homeController', function ($scope, userService, $location, adminService) {
        
    $scope.$parent.title = "Home";
    $scope.users = [];
    $scope.paginationPayload = { PageNumber: 1, PageSize: 20, Field: "Name" };
    $scope.sortCriteria = "";
    var currentSource = 1;
    
    
    $scope.GetUsers = function (payload) {
        adminService.GetUsers(payload).then(function (data) {
            $scope.users = data.adminUsers;
        });
    };

    $scope.next = function() {
        $scope.paginationPayload.PageNumber += 1;
        $scope.GetUsers($scope.paginationPayload);
    };

    $scope.back = function () {
        $scope.paginationPayload.PageNumber -= 1;
        $scope.GetUsers($scope.paginationPayload);
    };

    $scope.sort = function (param) {
        $scope.sortCriteria = param;
        $scope.paginationPayload.Field = param;
        $scope.GetUsers($scope.paginationPayload);
    };
    
    $scope.EnableUser = function(payload) {
        adminService.EnableUser(payload).then(function () {
            $scope.GetUsers($scope.paginationPayload);
        });
    };
    $scope.testStatePattern = function() {
        adminService.TestStatePattern().then(function(value) {
            $scope.statePattern = value;
        });
    };
    $scope.testNullObjectPattern = function() {
        adminService.TestNullObjectPattern().then(function (value) {
            $scope.nullObjectPattern = value;
        });
    }
    $scope.testObserverPattern = function () {
        adminService.ObserverPattern().then(function (value) {
            $scope.observerPattern = value;
        });
    }

    $scope.testBridgePattern = function () {
        adminService.BridgePattern(currentSource++).then(function (value) {
            $scope.bridgePattern = value;
        });
    }
    $scope.testVisitorPattern = function () {
        adminService.VisitorPattern().then(function (value) {
            $scope.visitorPattern = value;
        });
    }
    $scope.testBuilderPattern = function () {
        adminService.BuilderPattern().then(function (value) {
            $scope.builderPattern = value;
        });
    }
    $scope.testInterpreterPattern = function () {
        adminService.InterpreterPattern().then(function (value) {
            $scope.InterpreterPattern = value;
        });
    }
}); 