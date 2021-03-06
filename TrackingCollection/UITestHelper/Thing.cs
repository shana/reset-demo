﻿using GitHub.Collections;
using System;
using System.ComponentModel;

public class Thing : ICopyable<Thing>, IEquatable<Thing>, IComparable<Thing>, INotifyPropertyChanged
{
    public Thing(int id, string title, DateTimeOffset date1, DateTimeOffset date2)
    {
        this.Number = id;
        this.Title = title;
        this.CreatedAt = date1;
        this.UpdatedAt = date2;
    }

    public Thing()
    {
    }

    public void CopyFrom(Thing other)
    {
        Title = other.Title;
        CreatedAt = other.CreatedAt;
        UpdatedAt = other.UpdatedAt;
    }

    public bool Equals(Thing other)
    {
        if (ReferenceEquals(this, other))
            return true;
        return other != null && other.Number == Number;
    }

    public override bool Equals(object obj)
    {
        var other = obj as Thing;
        if (other != null)
            return Equals(other);
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return Number;
    }

    public int Number { get; set; }
    string title;
    public string Title
    {
        get { return title; }
        set { title = value; OnPropertyChanged(nameof(Title)); }
    }

    DateTimeOffset createdAt;
    public DateTimeOffset CreatedAt
    {
        get { return createdAt; }
        set { createdAt = value; OnPropertyChanged(nameof(CreatedAt)); }
    }

    DateTimeOffset updatedAt;
    public DateTimeOffset UpdatedAt
    {
        get { return updatedAt; }
        set { updatedAt = value; OnPropertyChanged(nameof(UpdatedAt)); }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public override string ToString()
    {
        return string.Format("id:{0} title:{1} created:{2:u} updated:{3:u}", Number, Title, CreatedAt, UpdatedAt);
    }

    public int CompareTo(Thing other)
    {
        return UpdatedAt.CompareTo(other.UpdatedAt);
    }
}
