Description: Library usage instructions.
---
To use Cake.Bower add the following line to the top of your cake script

```c#
#addin "Cake.Bower"
```

After this you can use the Bower property alias and call any of the commands that have been added. See [About Cake.Bower](../about.html) for details.

```c#
Task("Bower")
    .Does(() => {
        // bower install using bower.json
        Bower.Install();

        // bower install package and save
        Bower.Install("jquery", s => s.WithSave());

        // bower install in different directory
        Bower.Install(s => s.UseWorkingDirectory("./sub-dir-with-bower.json/"));
    });
```