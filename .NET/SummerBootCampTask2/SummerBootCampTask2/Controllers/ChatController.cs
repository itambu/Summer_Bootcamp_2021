using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SummerBootCampTask2.Contexts;
using SummerBootCampTask2.CoreModels;
using SummerBootCampTask2.Models;
using SummerBootCampTask2.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SummerBootCampTask2.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private readonly BootCampDbContext dbContext;
        private readonly IEncryptionService encryptionService;

        public ChatController(BootCampDbContext dbContext, IEncryptionService encryptionService)
        {
            this.dbContext = dbContext;
            this.encryptionService = encryptionService;
        }

        [HttpGet]
        public IActionResult Index(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var users = dbContext.Users.ToList();

            var user = users.FirstOrDefault(user => user.Email == User.Identity.Name);
            var friend = users.FirstOrDefault(user => user.Id == id);

            if (user is null || friend is null)
            {
                return NotFound();
            }

            var userFriend = dbContext.UserFriends
                .FirstOrDefault(x => (x.UserId == user.Id || x.FriendId == friend.Id)
                                && (x.UserId == friend.Id || x.FriendId == friend.Id));

            if (userFriend is null)
            {
                return RedirectToAction("Invite", "Invitation", new { id = id });
            }

            var chat = dbContext.Chats.FirstOrDefault(x => (x.FirstUserId == user.Id || x.SecondUserId == friend.Id)
                                && (x.FirstUserId == friend.Id || x.SecondUserId == friend.Id));

            return View(new ChatViewModel
            {
                Id = chat.Id,
                FriendId = friend.Id,
                Messages = GetMessages(chat.Id, user, friend),
                NewMessage = new MessageViewModel(),
            });
        }

        [HttpPost]
        public IActionResult SendMessage(ChatViewModel model)
        {
            var users = dbContext.Users.ToList();

            var user = users.FirstOrDefault(user => user.Email == User.Identity.Name);
            var friend = users.FirstOrDefault(user => user.Id == model.FriendId);
            var message = new Message
            {
                ChatId = model.Id,
                SenderId = user.Id,
                RecipientId = model.FriendId,
                Data = model.NewMessage.Message.Data,
                DateUpdated = DateTime.Now,
            };

            encryptionService.Encrypt(message, user.Key);
            dbContext.Messages.Add(message);
            dbContext.SaveChanges();
            return RedirectToAction("Index", new { id = friend.Id });
        }

        private List<MessageViewModel> GetMessages(int chatId, User user, User friend)
        {
            return dbContext.Messages.Where(x => x.ChatId == chatId).Select(message => new MessageViewModel
            {
                Sender = new ParticipantViewModel
                {
                    Id = message.SenderId,
                    UserName = message.SenderId == user.Id ? user.UserName : friend.UserName,
                },
                Recipient = new ParticipantViewModel
                {
                    Id = message.RecipientId,
                    UserName = message.RecipientId == user.Id ? user.UserName : friend.UserName,
                },
                Message = encryptionService.Decrypt(message, GetKey(message.SenderId, user, friend)),
            }).ToList();
        }

        private static int GetKey(int senderId, User user, User friend)
        {
            return senderId == user.Id ? user.Key : friend.Key;
        }
    }
}
