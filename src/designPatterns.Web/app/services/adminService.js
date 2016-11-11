angular.module('designPatterns.Services').factory("adminService", function ($httpq) {

    return {
        TemplatePattern: function () {
            return $httpq.get("/testTemplatePattern");
        },
        StrategyPattern: function () {
            return $httpq.get("/testStrategyPattern");
        },
        FactoryPattern: function () {
            return $httpq.get("/testFactoryPattern");
        },
        AdapterPattern: function () {
            return $httpq.get("/testAdapterPattern");
        },
        CommandPattern: function () {
            return $httpq.get("/testCommandPattern");
        },
        IteratorPattern: function () {
            return $httpq.get("/testIteratorPattern");
        },
        ChainOfResponsabilityPattern: function () {
            return $httpq.get("/testChainOfResponsabilityPattern");
        },
        InterpreterPattern: function () {
            return $httpq.get("/testInterpreterPattern");
        },
        BuilderPattern: function () {
            return $httpq.get("/testBuilderPattern");
        },
        VisitorPattern: function () {
            return $httpq.get("/testVisitorPattern");
        },
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