const express = require('express');
const app = express();
const cors = require('cors');
const morgan = require('morgan');
const rateLimit = require('express-rate-limit');
const helmet = require('helmet');
const mongoSanitize = require('express-mongo-sanitize');
const path = require('path');

const indexRoutes = require('./api/routers/indexRoutes');

const globalErrorHandler = require('./api/middlewares/globalErrorHandler');

const { NODE_ENV } = require('./config');

app.use(express.json());

// set security http headers
app.use(helmet());

if (NODE_ENV === 'development') {
	app.use(morgan('dev'));
}

// $ CORS
app.use(cors());

//  set limit request from same API in timePeroid from same ip
const limiter = rateLimit({
	max: 200, //   max number of limits
	windowMs: 60 * 1000, // Minute
	message: 'too many req from this IP, try again in a minute',
});

app.use('/api', limiter);

//  Body Parser  => reading data from body into req.body protect from scraping etc
app.use(express.json());

// Data sanitization against NoSql query injection
app.use(mongoSanitize()); //   filter out the dollar signs protect from  query injection attact

// testing middleware
app.use((req, res, next) => {
	// Auth stuff?
	next();
});

// routes
app.use('/api/v1', indexRoutes);

// handling all (get,post,update,delete.....) unhandled routes
app.all('*', (req, res, next) => {
	next(new Error(`Can't find ${req.originalUrl} on the server`, 404));
});

// error handling middleware
app.use(globalErrorHandler);

module.exports = app;
