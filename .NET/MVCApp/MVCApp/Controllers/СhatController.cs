using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCApp.Contexts;
using MVCApp.CoreModels;
using MVCApp.Models;
using MVCApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCApp.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private readonly MVCAppDbContext dbContext;
        private readonly IEncryptionService encryptionService;

        public ChatController(MVCAppDbContext dbContext, IEncryptionService encryptionService)
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

            var chat = dbContext.Chats.FirstOrDefault(chat => chat.Id == id);

            if (chat is null)
            {
                return NotFound();
            }

            var user = dbContext.Users.FirstOrDefault(user => user.Email == User.Identity.Name);

            int fId = chat.FirstUserId;
            int sId = chat.SecondUserId;
            if (user.Id != fId && user.Id != sId)
            {
                return NotFound();
            }

            var friendId = chat.FirstUserId == user.Id ? chat.SecondUserId : chat.FirstUserId;
   
            var relation = dbContext.UserFriends.FirstOrDefault(r => ((r.UserId == user.Id && r.FriendId == friendId)
                                                                   || (r.UserId == friendId && r.FriendId == user.Id))
                                                                   && (r.isVerified));
            if (relation is null)
            {
                return BadRequest();
            }

            DateTime? TimeChatDelete = null;
            if (user.Id == chat.FirstUserId)
            {
                TimeChatDelete = chat.FirstUserDeleteChatTime;
            }
            else
            {
                if (user.Id == chat.SecondUserId)
                {
                    TimeChatDelete = chat.SecondUserDeleteChatTime;
                }
            }

            var friend = dbContext.Users.FirstOrDefault(friend => friend.Id == friendId);
            return View(new ChatViewModel
            {
                Id = chat.Id,
                FriendId = friendId,
                Messages = GetMessages(chat.Id, user, friend),
                NewMessage = new MessageViewModel(),
                DeleteChatTime = TimeChatDelete,
            });

        }

        [HttpPost]
        public IActionResult SendMessage(ChatViewModel model)
        {
            var users = dbContext.Users.ToList();

            var user = users.FirstOrDefault(user => user.Email == User.Identity.Name);
            var friend = users.FirstOrDefault(friend => friend.Id == model.FriendId);

            var message = new Message
            {
                ChatId = model.Id,
                SenderId = user.Id,
                RecipientId = model.FriendId,
                Data = model.NewMessage.Message.Data,
                DateUpdate = DateTime.Now,
            };

            dbContext.Messages.Add(encryptionService.Encrypt(message, user.Key));
            dbContext.SaveChanges();
            return RedirectToAction("Index", new { id = model.Id });
        }


        private List<MessageViewModel> GetMessages(int chatId, User user, User friend)
        {
            List<MessageViewModel> model = new List<MessageViewModel>();

            var messages = dbContext.Messages.Where(x => x.ChatId == chatId).ToList();

            foreach (var msg in messages)
            {
                int key = msg.SenderId == user.Id ? user.Key : friend.Key;
                model.Add(new MessageViewModel
                {
                    SenderId = msg.SenderId,
                    SenderName = msg.SenderId == user.Id ? user.UserName : friend.UserName,
                    RecipientId = msg.RecipientId,
                    RecipientName = msg.RecipientId == user.Id ? user.UserName : friend.UserName,
                    Message = encryptionService.Decrypt(msg, key),
                    DateUpdate = msg.DateUpdate,
                });
            }
            return model;
        }

        public IActionResult ChatDeleted()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DeleteChat(int? id)
        {
            var chat = dbContext.Chats.FirstOrDefault(chat => chat.Id == id);
            
            if (chat is null)
            {
                return NotFound();
            }

            var user = dbContext.Users.FirstOrDefault(user => user.Email == User.Identity.Name);

            if (user.Id == chat.FirstUserId)
            {
                chat.FirstUserDeleteChatTime = DateTime.Now;
            }
            else
            {
                if (user.Id == chat.SecondUserId)
                {
                    chat.SecondUserDeleteChatTime = DateTime.Now;
                }
            }

            dbContext.SaveChanges();

            return RedirectToAction("ChatDeleted", "Chat");
        }
    }
}
