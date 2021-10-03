const catchAsync = require('../../utils/catchAsync');

const buildings = require('./result.json')

exports.getAllSites = catchAsync(async (req, res, next) => {

    // SEND RESPONSE
    res.status(200).json({
        status: 'success',
        results: buildings.length,
        data: {
            sites: buildings,
        },
    });
});

exports.getBuildingBySite = catchAsync(async (req, res, next) => {

    console.log(req.params);

    // SEND RESPONSE
    res.status(200).json({
        status: 'success',
        results: buildings.length,
        data: {
            site_name: buildings[req.params.site].name,
            buildings: buildings[req.params.site].buildings,
        },
    });
});