using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webforum.Areas.Identity.Data.Entites;
using Webforum.Gateways;

namespace Webforum.Pages
{
    public class ChatModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string UserID { get; set; }
        [BindProperty(SupportsGet = true)]
        public string DialogID { get; set; }
        [BindProperty]
        public string newInput { get; set; }
        [BindProperty]
        public string ChatID { get; set; }
        [BindProperty]
        public string newChatMessage { get; set; }
        public List<Message> ChatMessagesList { get; set; }

        public Chat Chat { get; set; }

        private DBGateway _DBGateway;

        public ChatModel(DBGateway DBGateway)
        {
            _DBGateway = DBGateway;
        }

        public async Task OnGetAsync()
        {
            
            Chat = await _DBGateway.CollectChat(UserID);
           
            if(DialogID != null)
            {
                ChatMessagesList = await _DBGateway.CollectChatMessages(DialogID);
            }
        }

        public async Task <ActionResult> OnPostAsync()
        {

            if(DialogID != null && newChatMessage != null)
            {
                
                    var chatMessage = new Message()
                    {
                        WebforumUserId = UserID,
                        Post = newChatMessage,
                        DialogId = DialogID
                    };
                    await _DBGateway.CreateChatMessage(chatMessage);
                
            }

            else if(DialogID != null && newInput == null)
            {
                return RedirectToPage("Chat", new { UserID = UserID, DialogID = DialogID });
            }

            else
            {
            var dialog = new Dialog()
            {
                WebforumUserId = UserID,
                ConversationalPartner = _DBGateway.FindUser(newInput).Result.Id,
                ChatId = ChatID
            };

             await _DBGateway.CreateDialog(dialog);

            }

            return RedirectToPage("Chat", new { UserID = UserID, DialogID = DialogID });

        }
    }
}
