const express = require('express');
const timetableController = require('../controllers/timetableController');
const userController = require('../controllers/userController');
const buildingsController = require('../controllers/buildingsController')

const router = express.Router();

router.route('/timetable').get(timetableController.fetch);

router.route('/users/').get(userController.getAllUsers);
router.route('/users/register').post(userController.createUser);

router.route('/buildings/').get(buildingsController.getAllBuildings);


module.exports = router;
