﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure;
using SocialNetworkDAL.Interfaces;

namespace SocialNetworkDAL.Entities
{
    public class Comment : IPostable, IEntity
    {
        public int Id { get; set; }

        [NotMapped]
        public string TableName { get; } = nameof(EntityFrameworkDbContext.Comments);

        [Required]
        public DateTime PostedAt { get; set; } = DateTime.Now.ToUniversalTime();

        [Required]
        [MaxLength(200)]
        public string Text { get; set; }

        public bool StayAnonymous { get; set; } = false;

        #region Foreign keys

        public int PostId { get; set; }
        public int UserId { get; set; }

        #endregion

        #region Navigation properties

        public virtual Post Post { get; set; }
        public virtual User User { get; set; }

        #endregion
    }
}