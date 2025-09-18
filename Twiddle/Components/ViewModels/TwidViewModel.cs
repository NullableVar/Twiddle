namespace Twiddle.Components.ViewModels;

internal class TwidViewModel
{
    public string Name { get; set; }
    
    public string Username { get; set; }
    
    public string TimeAgo { get; set; }
    
    public string Text { get; set; }
    
    public string AvatarInitials { get; set; }
    
    public string AvatarBackground { get; set; }
    
    public int Likes { get; set; }
    
    public int Comments { get; set; }
    
    public int Retweets { get; set; }
    
    public bool Liked { get; set; } = false;
}