// <fileheader>
//     <copyright file="Program.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
using Ordering.Api;
using Ordering.Application;
using Ordering.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();

// Configure the HTTP request pipeline
app.Run();
