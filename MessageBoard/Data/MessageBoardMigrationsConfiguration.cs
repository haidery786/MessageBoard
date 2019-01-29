using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;

namespace MessageBoard.Data
{
   public class MessageBoardMigrationsConfiguration :DbMigrationsConfiguration<MessageBoardContext>
    {
       public MessageBoardMigrationsConfiguration()
       {
           this.AutomaticMigrationDataLossAllowed = true;
           this.AutomaticMigrationsEnabled = true;
       }

       protected override void Seed(MessageBoardContext context)
       {
            base.Seed(context);

#if DEBUG
            if (context.Topics.Count() == 0  )
            {
                Topic topic = new Topic()
                {

                    Title= "I love AngularJs" ,
                    Created = DateTime.Now,
                    Body = "I love AngularJS using with MVC and want every one to use it",

                    Replies = new  List<Reply>
                    {
                        new Reply()
                        {
                            Created = DateTime.Now,
                            Body = "I love it too"
                        },
                         new Reply()
                        {
                            Created = DateTime.Now,
                            Body = "Me too"
                        },
                         new Reply()
                        {
                            Created = DateTime.Now,
                            Body = "I love it awsome"
                        },

                    }
                };

                context.Topics.Add(topic);

                var anothertopic = new Topic()
                {

                    Title = "I like Ruby on Rails Tool",
                    Created = DateTime.Now,
                    Body = "I like Ruby on Rails Tool and want every one to use it",

                };

                context.Topics.Add(anothertopic);

                try
                {
                    context.SaveChanges();

                }
                catch(Exception ex)
                {
                    var msg = ex.Message;
                }
            }

#endif 
       }
    }
}
