// IIFE: Immediately Invoking Function Expression
(function () {
    'use strict';
    angular.module('topics.module') // readonly
    .factory('topicsFactory', ['$http', '$q', function ($http, $q) {
        var urlpost = 'api/v1/topics/';
        var url = 'api/v1/topics?includereplies=true';
                    
        var _topics = [];
        var _isInit = false;

        var _isReady = function () {

            return _isInit;
        };

        var _gettopics= function () {

            var deferred = $q.defer();

            $http.get(url)
            .then(function (result) {
                //successfull
                angular.copy(result.data, _topics);
                _isInit = true;
                deferred.resolve();
            },
            function () {
                //error
                deferred.reject();
            });

            return deferred.promise;
        };

        var _addtopic = function (newtopic) {
            var deferred = $q.defer();
            $http.post(urlpost, newtopic)
            .then(function (result) {
                //Success
                var newlycreatedTopic = result.data;
                // TODO the merge with existing list of topics
                _topics.splice(0, 0, newlycreatedTopic);
                deferred.resolve(newlycreatedTopic);
            }),
            function () {
                //Error
                deferred.reject();
            };

            return deferred.promise;
        };

        function _findTopic(id)
        {
            var found = null;
            //alert(_topics.length);

            $(_topics).each(function (i, item) {
                if (item.id == id) {
                    found = item;
                    return false;
                }
            });
                  
            
            return found;
        }

        var _getTopicById = function (id) {
            var deferred = $q.defer();

            if (_isReady())
            {
                var topic = _findTopic(id);          
                if(topic)
                {
                    deferred.resolve(topic);
                } else {
                    deferred.reject();
                }

            } else {
                _gettopics()
                .then (function(){
                    //Success
                    var topic = _findTopic(id);
                    if (topic) {
                        deferred.resolve(topic);
                    } else {
                        deferred.reject();
                    }
                },
                function(){
                    //Error
                    deferred.reject();
                });

            }
            return deferred.promise;
        };

        var _saveReply = function (topic , newReply) {
            var deferred = $q.defer();
            
            $http.post("/api/v1/topics/"+topic.id +"/replies", newReply)
            .then(function (result) {
                //success

                if (topic.replies == null) topic.replies = [];
                topic.replies.push(result.data);

                deferred.resolve(result.data);
            },
            function () {

                //error

            });

            return deferred.promise;

        };

        return {
            topics:_topics,
            gettopics: _gettopics,
            addTopic: _addtopic,
            isReady: _isReady,
            getTopicById: _getTopicById,
            saveReply: _saveReply
        };



        //,
        //addApplication: function (application) {
        //    return $http.post(url, application);
        //},
        //deleteApplication: function (application) {
        //    return $http.delete(url + application.ID);
        //},
        //updateApplication: function (application) {
        //    return $http.put(url + application.ID, application);
        //}


       

    }]);
})();