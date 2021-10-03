const express = require('express');
const timetableController = require('../controllers/timetableController');
const userController = require('../controllers/userController');

const router = express.Router();

router.route('/timetable').get(timetableController.fetch);

router.route('/users/register').post(userController.createUser);

module.exports = router;
