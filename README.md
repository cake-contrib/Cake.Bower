# Cake.Bower

## Usage

```c#
    #addin "Cake.Bower"

    Task("Bower")
        .Does(() => {
            // bower install
            Bower.Install();

            // bower install package and save
            Bower
                .WithSave()
                .Install("jquery");
        });
```

## Scope
Cake.Bower currently supports the following bower commands:

* ```bower install```

Bower is officially deprecated, however my current build workflow requires it so I created the plugin to support that workflow. I've attempted to add other features to support other workflows.