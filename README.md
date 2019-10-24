# C# DosBox Library

C# library to manage DosBox applciation. Create your own DosBox launcher.

## Functions

- [x] Easy stater DosBox application (99%)
- [x] Edit DosBox options (98%)
- [ ] Edit Commands (1%)
- [ ] Edit Mapper (0%)
- [ ] Tools (in planning)

# Use

Simple starter DosBox application.

```C#
DosBoxStarter.FromProcess(@"c:\dosbox\dosbox.exe").Start();
```

Starter DosBox application with parameters. 

```C#
DosBoxStarter.FromProcess(@"c:\dosbox\dosbox.exe")
                .WithParameters(p => p.AddName(@"c:\war2")
                                      .AddFullscreen()
                                      .AddExit())
                .Start();
```

Starter DosBox application with parameters and custom configurations

```C#
DosBoxStarter.FromProcess(@"c:\dosbox\dosbox.exe")
                .WithParameters(p => p.AddName(@"c:\war2")
                                      .AddFullscreen()
                                      .AddExit())
                .WithIPXOptions(i => i.AddIPX(true))
                .WithAutoexecOptions(a => a.AddCommand("ipxnet startserver")
                                           .AddCommand("war2.exe"))
                .Start();
```

### Credits

Site: https://tioraclab.com/