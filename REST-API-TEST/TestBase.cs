﻿using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using REST_API.Data;
using REST_API.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace REST_API_TEST
{
    public class TestBase
    {
        public static DbContextOptions<ArticleContext> options = new DbContextOptionsBuilder<ArticleContext>()
            .UseInMemoryDatabase(databaseName: "testDatabase").Options;

        // Populate an in-memory database with data to work with.
        [SetUp]
        public void SetupDb()
        {
            using (var context = new ArticleContext(options))
            {
                context.User.AddRange(
                    new User
                    {
                        UserID = 1,
                        UserName = "JSON",
                        PassWord = "Jason"
                    },
                    new User
                    {
                        UserID = 2,
                        UserName = "Naruto",
                        PassWord = "Uzumaki"
                    }
                );

                context.Article.AddRange(
                    new Article()
                    {
                        ArticleID = 1,
                        UserID = 1, // Make JSON the author.
                        CreatedDate = DateTime.UtcNow,
                        Title = "Procastination",
                        Introduction = "Why do we spend time doing other things unrelated to the matter?"
                    }
                );

                context.ArticleField.AddRange(
                    new ArticleField
                    {
                        FieldID = 1,
                        ArticleID = 1,
                        Name = "Why do we Procastinate?",
                        Value = "We may spend this procastination time doing something else which is of interest or maybe more productive. Like for example, at the time of writing this article, I spend like 80% of the time I should do this playing Minecraft instead."
                    },
                    new ArticleField
                    {
                        FieldID = 2,
                        ArticleID = 1,
                        Name = "Is Procastination good?",
                        Value = "It depends, if we waste too much time procastinating, it can be bad, but it is almost always unavoidable especially when due dates are days away. This is where last minute work happens to some people."
                    }
                );

                context.SaveChanges();
            }
        }

        // Clear the database for the next test.
        [TearDown]
        public void ClearDb()
        {
            using (var context = new ArticleContext(options))
            {
                foreach (var entity in context.User)
                {
                    context.User.Remove(entity);
                }

                foreach (var entity in context.Article)
                {
                    context.Article.Remove(entity);
                }

                foreach (var entity in context.ArticleField)
                {
                    context.ArticleField.Remove(entity);
                }

                context.SaveChanges();
            };
        }
    }
}
