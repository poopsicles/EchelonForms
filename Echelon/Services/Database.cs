using System;
using System.Collections.Generic;
using System.Linq;
using Echelon.Models;

namespace Echelon.Services;
internal class Database
{
    public static int AddUser(string name, string password)
    {
        // Takes a name and a password and generates keys
        // and adds to the database and returns the UserID
        var UserID = 0;

        using (var db = new DatabaseContext())
        {
            byte[] hash = Crypto.GetHash(password);
            byte[][] keyPair = Crypto.NewPrivatePublic(password);

            db.Add(new User
            {
                Name = name,
                PasswordHash = hash,
                PublicKey = keyPair[0],
                ProtectedPrivateKey = keyPair[1]
            });

            db.SaveChanges();

            UserID = db.Users.OrderBy(c => c.UserID).Last().UserID;
        }

        return UserID;
    }

    public static int AddNote(int UserID)
    {
        // Takes a UserID and creates a new note
        // returns: the ID of the newly-created note
        var NoteID = 0;

        using (var db = new DatabaseContext())
        {
            // get the public key of the user
            var publicKey = db.Users.Where(c => c.UserID == UserID).First().PublicKey;

            byte[] noteKey = Crypto.NewSymmetricKey();
            byte[] encryptedTitle = Crypto.EncryptString(noteKey, "");
            byte[] encryptedBody = Crypto.EncryptString(noteKey, "");
            byte[] encryptedKey = Crypto.EncryptBytes(publicKey, noteKey);

            db.Add(new Note
            {
                UserID = UserID,
                EncryptedKey = encryptedKey,
                EncryptedTitle = encryptedTitle,
                EncryptedBody = encryptedBody,
                LastModified = DateTime.Now,
            });

            db.SaveChanges();

            NoteID = db.Notes.OrderBy(c => c.NoteID).Last().NoteID;
        }

        return NoteID;
    }

    public static string[] GetNoteContents(int NoteID, byte[] PrivateKey)
    {
        // takes a NoteID and a private key and returns the contents of the note
        string[] noteContents = new string[3];

        using (var db = new DatabaseContext())
        {
            var note = db.Notes.Where(c => c.NoteID == NoteID).First();
            var noteKey = Crypto.DecryptBytes(PrivateKey, note.EncryptedKey);
            var title = Crypto.DecryptString(noteKey, note.EncryptedTitle);
            var body = Crypto.DecryptString(noteKey, note.EncryptedBody);

            noteContents[0] = title;
            noteContents[1] = body;
            noteContents[2] = note.LastModified.ToString("f");
        }

        return noteContents;
    }

    public static void UpdateNote(int NoteID, byte[] PrivateKey, string title, string body)
    {
        // Takes a NoteID and a private key, and writes the new contents to it

        using (var db = new DatabaseContext())
        {
            var note = db.Notes.Where(c => c.NoteID == NoteID).First();
            var noteKey = Crypto.DecryptBytes(PrivateKey, note.EncryptedKey);

            note.EncryptedTitle = Crypto.EncryptString(noteKey, title);
            note.EncryptedBody = Crypto.EncryptString(noteKey, body);
            note.LastModified = DateTime.Now;

            db.SaveChanges();
        }
    }

    public static int DropNote(int id)
    {
        // Drops a note and returns 0 if successful

        using (var db = new DatabaseContext())
        {
            var note = db.Notes.Where(c => c.NoteID == id).First();
            if (note == null)
            {
                return 1;
            }

            db.Remove(note);
            db.SaveChanges();
        }
            
        return 0;
    }
}

