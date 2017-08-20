# Cake.Bower

## Information

### Build Status

Branch | Status
--- | ---
Master | [![Build status](https://ci.appveyor.com/api/projects/status/17x9uhlfja50wdk3/branch/master?svg=true)](https://ci.appveyor.com/project/cakecontrib/cake-bower/branch/master)
Dev | [![Build status](https://ci.appveyor.com/api/projects/status/17x9uhlfja50wdk3/branch/dev?svg=true)](https://ci.appveyor.com/project/cakecontrib/cake-bower/branch/dev)

### Nuget
[![NuGet](https://img.shields.io/nuget/v/Cake.Bower.svg)](https://www.nuget.org/packages/Cake.Bower/) 

### Licence
[![License](http://img.shields.io/:license-mit-blue.svg)](http://cake-contrib.mit-license.org)

## Usage

Build the Cake.Bower.dll then use as follows

```c#
    #reference "bin/Cake.Bower.dll"

    Task("Bower")
        .Does(() => {
            // bower install
            Bower.Install();

            // bower install package and save
            Bower.Install("jquery", s => s.WithSave());

            // bower install in different directory
            Bower.Install(s => s.UseWorkingDirectory("./sub-dir-with-bower.json/"));
        });
```

## Scope
Cake.Bower currently supports the following bower commands:

* ```bower cache```
* ```bower help```
* ```bower home```
* ```bower info```
* ```bower install```
* ```bower link```

Bower is officially deprecated, however my current build workflow requires it so I created the plugin to support that workflow.
Other commands will get added as and when I get time, but pull requests are welcome.

## Thanks
Big thanks to everyone who has worked on Cake - it's a great tool
The Cake.Yarn repo provided me with the template for getting started with this, so a big thanks to them or I'd still be scratching my head.