/// <reference path="d:\c#learningprojects\messageboard\messageboard.test\scripts\jasmine.js" />
/// <reference path="../../messageboard/scripts/angular.js" />
/// <reference path="../../messageboard/scripts/angular-mocks.js" />
/// <reference path="../../messageboard/app/app.module.js" />
/// <reference path="../../messageboard/app/topics/topics.module.js" />
/// <reference path="../../messageboard/app/topics/topics.controller.js" />
/// <reference path="../../messageboard/app/topics/topics.service.js" />

describe("topics.module Tests->", function () {

    beforeEach(function () {
        module("topics.module");
    });  

    var $httpBackend;
    beforeEach(inject(function ($injector) {

        // Set up the mock http service responses
        $httpBackend = $injector.get('$httpBackend');

        $httpBackend.when('GET', 'api/v1/topics?includereplies=true')
        .respond([
            {
                title: "First Topic",
                body: "First Topic Body",
                id: 1,
                created: "20150913"
            },
            {
                title: "2nd Topic",
                body: "2nd Topic Body",
                id: 2,
                created: "20150913"
            }
        ]);

    }));

    afterEach(function () {
        $httpBackend.verifyNoOutstandingExpectation();
        $httpBackend.verifyNoOutstandingRequest();
    });


    describe("topicsFactory->", function () {

        it("can load Topics", inject(function (topicsFactory) {

            expect(topicsFactory.topics).toEqual([]);
            $httpBackend.expectGET("api/v1/topics?includereplies=true");
            topicsFactory.gettopics();

            $httpBackend.flush();
            expect(topicsFactory.topics.length).toBeGreaterThan(0);
            expect(topicsFactory.topics.length).toEqual(2);                
        }));
    });


    describe("TopicsController->", function () {
        it("load data", inject(function ($controller, topicsFactory) {

            var theScope = {};

            $httpBackend.expectGET("api/v1/topics?includereplies=true");

            var ctrl = $controller("TopicsController", {
                $scope: theScope,
                topicsFactory: topicsFactory

            });

            $httpBackend.flush();
            expect(ctrl).not.toBeNull();
            expect(theScope.data).toBeDefined();


        }));

    });


});