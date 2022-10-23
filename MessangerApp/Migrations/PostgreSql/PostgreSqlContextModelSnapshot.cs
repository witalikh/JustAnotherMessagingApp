﻿// <auto-generated />
using System;
using MessangerApp.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MessangerApp.Migrations.PostgreSql
{
    [DbContext(typeof(PostgreSqlContext))]
    partial class PostgreSqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MessangerApp.Entities.Chats.Chat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsFilesSendingOnByDefault")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsInvitesSendingOnByDefault")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsMessagingOnByDefault")
                        .HasColumnType("boolean");

                    b.Property<string>("JoinLink")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer");

                    b.Property<int>("Visibility")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("MessangerApp.Entities.Chats.ChatBlacklist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ChatId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("UserId");

                    b.ToTable("ChatBlacklists");
                });

            modelBuilder.Entity("MessangerApp.Entities.Chats.ChatInvitation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ChatId")
                        .HasColumnType("integer");

                    b.Property<int>("InvitedById")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("InvitedById");

                    b.HasIndex("UserId");

                    b.ToTable("ChatInvitations");
                });

            modelBuilder.Entity("MessangerApp.Entities.Chats.ChatJoinRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ApprovedById")
                        .HasColumnType("integer");

                    b.Property<int>("ChatId")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ApprovedById");

                    b.HasIndex("ChatId");

                    b.HasIndex("UserId");

                    b.ToTable("ChatJoinRequests");
                });

            modelBuilder.Entity("MessangerApp.Entities.Chats.ChatMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ChatId")
                        .HasColumnType("integer");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("ChatMembers");
                });

            modelBuilder.Entity("MessangerApp.Entities.Chats.ChatRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("CanApproveJoinRequests")
                        .HasColumnType("boolean");

                    b.Property<bool>("CanInvitePeople")
                        .HasColumnType("boolean");

                    b.Property<bool>("CanMessage")
                        .HasColumnType("boolean");

                    b.Property<bool>("CanSendFiles")
                        .HasColumnType("boolean");

                    b.Property<int>("ChatId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.ToTable("ChatRoles");
                });

            modelBuilder.Entity("MessangerApp.Entities.Messages.AdditionalContent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("MessageId")
                        .HasColumnType("integer");

                    b.Property<string>("Payload")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MessageId");

                    b.ToTable("AdditionalContents");
                });

            modelBuilder.Entity("MessangerApp.Entities.Messages.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ChatId")
                        .HasColumnType("integer");

                    b.Property<int?>("ChatMemberId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("HasAdditionalContext")
                        .HasColumnType("boolean");

                    b.Property<int>("MemberId")
                        .HasColumnType("integer");

                    b.Property<string>("Payload")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("ChatMemberId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("MessangerApp.Entities.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MessangerApp.Entities.Users.UserBlacklist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BlacklistedUserId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BlacklistedUserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserBlacklists");
                });

            modelBuilder.Entity("MessangerApp.Entities.Chats.Chat", b =>
                {
                    b.HasOne("MessangerApp.Entities.Users.User", "Owner")
                        .WithMany("OwnedChats")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("MessangerApp.Entities.Chats.ChatBlacklist", b =>
                {
                    b.HasOne("MessangerApp.Entities.Chats.Chat", "Chat")
                        .WithMany("BlackLists")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MessangerApp.Entities.Users.User", "User")
                        .WithMany("ChatBlacklists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MessangerApp.Entities.Chats.ChatInvitation", b =>
                {
                    b.HasOne("MessangerApp.Entities.Chats.Chat", "Chat")
                        .WithMany("Invitations")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MessangerApp.Entities.Chats.ChatMember", "InvitedBy")
                        .WithMany("SentInvitations")
                        .HasForeignKey("InvitedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MessangerApp.Entities.Users.User", "User")
                        .WithMany("Invitations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("InvitedBy");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MessangerApp.Entities.Chats.ChatJoinRequest", b =>
                {
                    b.HasOne("MessangerApp.Entities.Chats.ChatMember", "ApprovedBy")
                        .WithMany("JoinRequestsToApprove")
                        .HasForeignKey("ApprovedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MessangerApp.Entities.Chats.Chat", "Chat")
                        .WithMany("JoinRequests")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MessangerApp.Entities.Users.User", "User")
                        .WithMany("JoinRequests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApprovedBy");

                    b.Navigation("Chat");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MessangerApp.Entities.Chats.ChatMember", b =>
                {
                    b.HasOne("MessangerApp.Entities.Chats.Chat", "Chat")
                        .WithMany("Members")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MessangerApp.Entities.Chats.ChatRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MessangerApp.Entities.Users.User", "User")
                        .WithMany("Memberships")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MessangerApp.Entities.Chats.ChatRole", b =>
                {
                    b.HasOne("MessangerApp.Entities.Chats.Chat", "Chat")
                        .WithMany()
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");
                });

            modelBuilder.Entity("MessangerApp.Entities.Messages.AdditionalContent", b =>
                {
                    b.HasOne("MessangerApp.Entities.Messages.Message", "Message")
                        .WithMany("AdditionalContents")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Message");
                });

            modelBuilder.Entity("MessangerApp.Entities.Messages.Message", b =>
                {
                    b.HasOne("MessangerApp.Entities.Chats.Chat", "Chat")
                        .WithMany("Messages")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MessangerApp.Entities.Chats.ChatMember", "ChatMember")
                        .WithMany("Messages")
                        .HasForeignKey("ChatMemberId");

                    b.Navigation("Chat");

                    b.Navigation("ChatMember");
                });

            modelBuilder.Entity("MessangerApp.Entities.Users.UserBlacklist", b =>
                {
                    b.HasOne("MessangerApp.Entities.Users.User", "BlacklistedUser")
                        .WithMany("BlacklistedUsers")
                        .HasForeignKey("BlacklistedUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MessangerApp.Entities.Users.User", "User")
                        .WithMany("UserBlacklists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BlacklistedUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MessangerApp.Entities.Chats.Chat", b =>
                {
                    b.Navigation("BlackLists");

                    b.Navigation("Invitations");

                    b.Navigation("JoinRequests");

                    b.Navigation("Members");

                    b.Navigation("Messages");
                });

            modelBuilder.Entity("MessangerApp.Entities.Chats.ChatMember", b =>
                {
                    b.Navigation("JoinRequestsToApprove");

                    b.Navigation("Messages");

                    b.Navigation("SentInvitations");
                });

            modelBuilder.Entity("MessangerApp.Entities.Messages.Message", b =>
                {
                    b.Navigation("AdditionalContents");
                });

            modelBuilder.Entity("MessangerApp.Entities.Users.User", b =>
                {
                    b.Navigation("BlacklistedUsers");

                    b.Navigation("ChatBlacklists");

                    b.Navigation("Invitations");

                    b.Navigation("JoinRequests");

                    b.Navigation("Memberships");

                    b.Navigation("OwnedChats");

                    b.Navigation("UserBlacklists");
                });
#pragma warning restore 612, 618
        }
    }
}
