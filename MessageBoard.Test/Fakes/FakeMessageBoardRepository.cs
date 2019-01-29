using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessageBoard.Data;

namespace MessageBoard.Test.Fakes
{

   class FakeMessageBoardRepository : IMessageBoardRepository 
    {       
       public  bool Save()
       {

           return true;
       }
        public bool AddTopic(Topic newTopic)
       {
           newTopic.Id = 1;
           return true;
       }

        public bool AddReply(Reply newReply)
        {

            return true;
        }

        public IQueryable<Topic> GetTopics()
        {
            return new Topic[]
            {
                new Topic
                {
                    Id = 1 ,
                    Title = "Boostrap",
                    Body = "I love Bootstrap",
                    Created = DateTime.UtcNow
                },
                 new Topic
                {
                    Id = 2 ,
                    Title = "AngularJs",
                    Body = "I Love AngularJS",
                    Created = DateTime.UtcNow
                },
                 new Topic
                {
                    Id = 3 ,
                    Title = "MVC using AngularJS",
                    Body = "I love using both flavours",
                    Created = DateTime.UtcNow
                },

            }.AsQueryable();
        }

        public IQueryable<Topic> GetTopicsIncludingReplies()
        {
            return new Topic[]
            {
                new Topic
                {
                    Id = 1 ,
                    Title = "Boostrap",
                    Body = "I love Bootstrap",
                    Created = DateTime.UtcNow
                },
                 new Topic
                {
                    Id = 2 ,
                    Title = "AngularJs",
                    Body = "I Love AngularJS",
                    Created = DateTime.UtcNow
                },
                 new Topic
                {
                    Id = 3 ,
                    Title = "MVC using AngularJS",
                    Body = "I love using both flavours",
                    Created = DateTime.UtcNow
                },

            }.AsQueryable();

        }
        public IQueryable<Reply> GetRepliesByTopic(int topicId)
        {

            return new Reply[]
            {
                new Reply
                {
                    Id = 1 ,
                    Body = "I love Bootstrap",
                    Created = DateTime.UtcNow,
                    Topicid= 1
                },
                 new Reply
                {
                    Id = 2 ,
                    Body = "I Love AngularJS",
                    Created = DateTime.UtcNow,
                    Topicid= 1
                },
                 new Reply
                {
                    Id = 3 ,
                    Body = "I love using both flavours",
                    Created = DateTime.UtcNow,
                    Topicid= 1
                },
                  new Reply
                {
                    Id = 4 ,
                    Body = "I love using both flavours",
                    Created = DateTime.UtcNow,
                    Topicid= 1
                },

            }.AsQueryable();
        }

    }
}
