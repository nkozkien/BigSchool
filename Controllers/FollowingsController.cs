using BigSchool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BigSchool.App_Start
{
    public class FollowingsController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Follow(Following follow)
        {
            var userID = User.Identity.GetUserId();
           
            if (userID == null)
                return BadRequest("Please login fisrt!");
            if (userID == follow.FolloweeId)
              return BadRequest("Can not follow myseft!");
            BigSchoolContext context = new BigSchoolContext();
            Following find = context.Followings.FirstOrDefault(p => p.FollowerId == userID && p.FolloweeId == follow.FolloweeId);
            if (find != null)

            {
                //return BadRequest("The already following exists!");
                context.Followings.Remove(context.Followings.SingleOrDefault(p =>
                        p.FollowerId == userID && p.FolloweeId == follow.FolloweeId));
                context.SaveChanges();
                return Ok("cancel");
            }
            follow.FollowerId = userID;
            context.Followings.Add(follow);
            context.SaveChanges();
            return Ok();
        }
    }
}
