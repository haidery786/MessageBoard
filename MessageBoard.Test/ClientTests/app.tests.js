/// <reference path="d:\c#learningprojects\messageboard\messageboard.test\scripts\jasmine.js" />
/// <reference path="../../messageboard/js/myapp.js" />

describe("myApp tests->", function () {

    it("isDebug", function () {
        expect(app.isDebug).toEqual(true);
    });

    it("log", function () {

        expect(app.log).toBeDefined();
        app.log("testing");
    });



});