'use strict';

Object.defineProperty(exports, "__esModule", {
	value: true
});

var _noop = require('./noop');

var _noop2 = _interopRequireDefault(_noop);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

var defaultProps = {
	name: 'Form',
	action: '/',
	canSubmit: true,
	onSubmit: _noop2.default,
	onSuccess: _noop2.default,
	onError: _noop2.default,
	validate: _noop2.default,
	honeypotName: '__bf'
};

exports.default = defaultProps;