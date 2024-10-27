// <fileheader>
//     <copyright file="Program.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
var builder = WebApplication.CreateBuilder(args);

// Add services to the container
var app = builder.Build();

// Configure the HTTP request pipeline
app.Run();