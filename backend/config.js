require('dotenv').config();

module.exports = {
    DATABASE: 'mongodb+srv://Admin:<PASSWORD>@cluster0.sbawc.mongodb.net/expressBoiler?retryWrites=true&w=majority',
    DATABASE_LOCAL: 'mongodb://localhost:27017/expressBoiler',
    DATABASE_PASSWORD: 'rEWyMCXxXeZbwPJl',
    NODE_ENV: 'development',
    PORT: 5000,

    Email_From: 'UmadAhmad1928@gmail.com',
    Sendgrid_Password: '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',
    Sendgrid_Username: 'apikey',

    JWT_SECRET: 'my-ultra-secure-and-ultra-long-secret',
    JWT_EXPIRES_IN: '90d',
    JWT_COOKIE_EXPIRES_IN: 90,
};