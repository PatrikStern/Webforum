using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webforum.Areas.Identity.Data;
using Webforum.Areas.Identity.Data.Entites;
using Webforum.Data;

namespace Webforum.Gateways
{
    public class DBGateway /*: IDBGateway*/
    {
        private readonly WebforumContext _context;

        public DBGateway(WebforumContext context)
        {
            _context = context;
        }

        public async Task <Subject> CreateSubject(Subject subject)
        {
            await _context.Subjects.AddAsync(subject);
            await _context.SaveChangesAsync();
            return subject;
        }
        public async Task<Category> CreateCategory(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<HeadLines> CreateHeadLine(HeadLines headline)
        {
            await _context.HeadLines.AddAsync(headline);
            await _context.SaveChangesAsync();
            return headline;
        }

        public async Task<PostThread> CreatePostThread(PostThread thread)
        {
            await _context.Threads.AddAsync(thread);
            await _context.SaveChangesAsync();
            return thread;
        }

        public async Task<Posts> CreatePost(Posts post)
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task <Dialog> CreateDialog(Dialog dialog)
        {
            await _context.Dialogs.AddAsync(dialog);
            await _context.SaveChangesAsync();
            return dialog;
        }

        public async Task<Message> CreateChatMessage(Message message)
        {
            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();
            return message;
        }

        public List<Subject> CollectForumOverview()
        {
            var listOfSubjects =  _context.Subjects.Include(x => x.Categories).ThenInclude(x => x.HeadLines).ThenInclude(x => x.Threads).ThenInclude(x => x.Posts).ToList();
            return listOfSubjects;
        }

        public async Task <List<HeadLines>> CollectCategoryOverview(string CategoryID)
        {
            var listOfTopics = await _context.HeadLines.Include(x => x.Threads).ThenInclude(x => x.Posts).Where(x => x.CategoryId == CategoryID).ToListAsync();
            return listOfTopics;
        }

        public async Task <List<PostThread>> CollectThreadTopicsOverview(string HeadLineID)
        {
            var listOfThreadTopics = await _context.Threads.Include(x => x.Posts).ThenInclude(x => x.Comments).Where(x => x.HeadLinesId == HeadLineID).ToListAsync();
            return listOfThreadTopics;
        }

        public async Task<List<Posts>> CollectPosts(string ThreadID)
        {
            var listOfPosts = await _context.Posts.Include(x => x.Comments).Where(x => x.PostThreadId == ThreadID).ToListAsync();
            return listOfPosts;
        }

        public async Task<Chat> CollectChat(string UserID)
        {
            var existingChat = await _context.Chats.Where(x => x.WebforumUserId == UserID).FirstOrDefaultAsync();

            if (existingChat != null)
            {
                var collectDialogs = await _context.Dialogs.Include(x => x.Messages).Where(x => x.WebforumUserId == UserID || x.ConversationalPartner == UserID).ToListAsync();
                if(collectDialogs.Count > 0)
                {
                existingChat.Dialogs = collectDialogs;
                }
                return existingChat;
            }

            else
            {
                var newChat = new Chat()
                {
                    WebforumUserId = UserID
                };

                await _context.Chats.AddAsync(newChat);
                await _context.SaveChangesAsync();
                var chat = await _context.Chats.Where(x => x.WebforumUserId == UserID).FirstOrDefaultAsync();
                var collectDialogsToNew = await _context.Dialogs.Include(x => x.Messages).Where(x => x.WebforumUserId == UserID || x.ConversationalPartner == UserID).ToListAsync();
                if(collectDialogsToNew.Count > 0) 
                { 
                chat.Dialogs = collectDialogsToNew;
                }
                return chat;
            }
            
        }

        public async Task <List<Message>> CollectChatMessages(string DialogID)
        {
            var listOfChatMessages = await _context.Messages.Where(x => x.DialogId == DialogID).ToListAsync();
            return listOfChatMessages;
        }
        public async Task<List<Posts>> CollectReportedPosts()
        {
            var reportedPosts = await _context.Posts.Where(x => x.ReportedPost == true).ToListAsync();

            return reportedPosts;
        }

        public WebforumUser FindUserForComponent(string UserID)
        {
            var user =  _context.Users.Where(x => x.Id == UserID).FirstOrDefault();
            return user;
        }
        public async Task<WebforumUser> FindUser(string UserIDOrUserName)
        {
            var user = await _context.Users.Where(x => x.Id == UserIDOrUserName || x.UserName == UserIDOrUserName).FirstOrDefaultAsync();
            return user;
        }
        public async Task UpdateUser(WebforumUser user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
        }
        public async Task<string> FindCatagory(string CatagoryID)
        {
            var catagory = await _context.Categories.Where(x => x.Id == CatagoryID).Select(x => x.Name).FirstOrDefaultAsync();
            return catagory;
        }
        public async Task<string> FindHeadLineTitel(string HeadLineID)
        {
            var HeadLine = await _context.HeadLines.Where(x => x.Id == HeadLineID).Select(x => x.HeadLine).FirstOrDefaultAsync();
            return HeadLine;
        }
        public async Task <string> FindThreadName(string ThreadID)
        {
            var ThreadName = await _context.Threads.Where(x => x.Id == ThreadID).Select(x => x.Titel).FirstOrDefaultAsync();
            return ThreadName;
        }
        public async Task<string> ReportPost(string PostID)
        {
            var reportPost = await _context.Posts.Where(x => x.Id == PostID).FirstOrDefaultAsync();

            reportPost.ReportedPost = true;
            _context.Update(reportPost);
            await _context.SaveChangesAsync();

            return PostID;
        }
        public async Task<string> DeletePost(string postToDelete)
        {
            var posttoDelete = await _context.Posts.Where(x => x.Id == postToDelete).FirstOrDefaultAsync();
            posttoDelete.deletedByAdmin = true;
            _context.Update(posttoDelete);
            await _context.SaveChangesAsync();
            return postToDelete;
        }
      
    }
}
