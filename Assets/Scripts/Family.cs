using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Family {

    string name;

    House home;
    Villager husband;
    Villager wife;
    List<Villager> children;

    public string getFamilyName()
    {
        return name;
    }

    public Family(string name, Villager husband, Villager wife)
    {
        this.name = name;
        this.husband = husband;
        this.wife = wife;

        children = new List<Villager>();
    }

    public bool marry(Villager wife)
    {
        if (this.wife != null)
            return false;

        this.wife = wife;
        return true;
    }

    public void childBorn(Villager child)
    {
        children.Add(child);
    }

    public bool startNewFamily(Villager child)
    {
        if (!children.Remove(child))
            return false;

        child.newFamily();
        return true;
    }

    public void setHome(House house)
    {
        home = house;
    }

    public House getHome()
    {
        return home;
    }
}
