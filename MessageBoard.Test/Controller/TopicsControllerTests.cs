﻿using MessageBoard.Controllers;
using MessageBoard.Data;
using MessageBoard.Test.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;
using Newtonsoft.Json;

namespace MessageBoard.Test.Controller
{
    [TestClass]
    public class TopicsControllerTests
    {
        private  TopicsController _ctrl;

      
        [TestInitialize]
        public void Init()
        {
             _ctrl = new TopicsController(new FakeMessageBoardRepository());
           
        }

        [TestMethod]
        public void TopicsController_Get()
        {

           var result = _ctrl.Get(true);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() > 0);
            Assert.IsNotNull(result.First());
            Assert.IsNotNull(result.First().Title);

        }

        [TestMethod]
        public void TopicsController_Post()
        {
            var config = new HttpConfiguration();
          
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/v1/topics");
            
            var route = config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}");
            
            var routeData = new HttpRouteData(route, new HttpRouteValueDictionary { { "controller", "topics" } });
            
            
            _ctrl.ControllerContext = new HttpControllerContext(config, routeData, request);

            _ctrl.Request = request;

            _ctrl.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
           
            var newTopic = new Topic()
            {
                Title = "A new Test Topic",
                Body = "This is the body of new test topic"

            };

            var result = _ctrl.Post(newTopic);

            Assert.AreEqual(HttpStatusCode.Created, result.StatusCode);

            var json = result.Content.ReadAsStringAsync().Result;

            var topic = JsonConvert.DeserializeObject<Topic>(json);

            Assert.IsNotNull(topic);
            Assert.IsTrue(topic.Id > 0);
            Assert.IsTrue(topic.Created > DateTime.MinValue);

        }
    }
}
