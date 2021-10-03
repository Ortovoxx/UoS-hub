const mongoose = require('mongoose');

const userSchema = new mongoose.Schema({
	firstname: String,
	surname: String,
	ical: String,
	timetable: [
		{
			start: Date,
			end: Date,
			length_ms: Number,
			title: String,
			location: String,
		}
	],
	map: {
		favourites: [ // Favourite buildings ( might include library and stags etc )
			String,
		],
		timetable: [
			String,
		], // Include societies
	},
	hall: String,
	school: String,
	soton_id: Number,
});

const User = mongoose.model('User', userSchema);
module.exports = User;