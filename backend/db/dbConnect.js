const mongoose = require('mongoose');
const { DATABASE_URL, DATABASE_PASSWORD } = require('../config');

module.exports = () => {
  console.log('connecting to DB...');
  mongoose
    .connect(DATABASE_URL.split('<PASSWORD>').join(DATABASE_PASSWORD), {
      useNewUrlParser: true,
    })
    .then(() => console.log(`DB connection successful!`))
    .catch((err) => {
      console.log('DB Connection Failed !');
      console.log(`err`, err);
    });
};
