using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Entities
{
    public class Follower:Base<long>
    {
        public long FollowerId { get; set; }
        public long PersonId { get; set; }
        public long PageId { get; set; }

        public virtual Person Person { get; set; }
        public virtual Page Page { get; set; }


    }
}
