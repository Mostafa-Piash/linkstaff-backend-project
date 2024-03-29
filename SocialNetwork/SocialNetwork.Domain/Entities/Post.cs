﻿using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Domain.Entities
{
    public class Post : Base<long>
    {
        [Required]
        public string Status { get; set; }
        public long? CreatedByPerson { get; set; }
        public long? CreatedByPage { get; set; }

        public virtual Person Person { get; set; }
        public virtual Page Page { get; set; }

    }
}
