require('dotenv').config();

module.exports = {
    DATABASE_URL: 'mongodb+srv://ortovox-mongo-dev:<PASSWORD>@rh-cluster-0.rzlzp.mongodb.net/RH-Cluster-0?retryWrites=true&w=majority',
    DATABASE_PASSWORD: process.env.DATABASE_PASSWORD,
    NODE_ENV: 'development',
    PORT: process.env.PORT || 5000,

    Email_From: 'UmadAhmad1928@gmail.com',
    Sendgrid_Password: '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',
    Sendgrid_Username: 'apikey',

    JWT_SECRET: 'my-ultra-secure-and-ultra-long-secret',
    JWT_EXPIRES_IN: '90d',
    JWT_COOKIE_EXPIRES_IN: 90,
};