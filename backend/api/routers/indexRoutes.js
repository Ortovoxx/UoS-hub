const express = require('express');
const timetableController = require('../controllers/timetableController');

const router = express.Router();

router.route('/timetable').get(timetableController.fetch);

module.exports = router;
