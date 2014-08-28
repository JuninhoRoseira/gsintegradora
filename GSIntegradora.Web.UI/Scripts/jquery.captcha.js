(function ($) {
	$.fn.captcha = function (options) {
		options = $.extend({}, $.fn.captcha.defaults, options);

		var randString = function (x) {
			var s = "";

			while (s.length < x && x > 0) {
				var r = Math.random();

				s += (r < 0.1 ? Math.floor(r * 100) : String.fromCharCode(Math.floor(r * 26) + (r > 0.5 ? 97 : 65)));

			}

			return s;

		};

		var createCaptchaForInput = function (element) {
			var $input = $(element);
			var $captcha = $("<SPAN />").insertAfter($input);

			$captcha
				.text(randString(options.length))
				.attr({
					'unselectable': 'on',
					'title': 'Clique para renovar',
					'id': $input.attr("id") + "-span"
				})
				.css({
					'-moz-user-select': '-moz-none',
					'-moz-user-select': 'none',
					'-o-user-select': 'none',
					'-khtml-user-select': 'none', /* you could also put this in a class */
					'-webkit-user-select': 'none', /* and add the CSS class here instead */
					'-ms-user-select': 'none',
					'user-select': 'none',
					"display": "inline-block",
					"border": "1px solid",
					"padding": "2px",
					"font-size": "12px",
					"margin-left": "4px",
					"margin-right": "4px",
					"text-align": "center",
					"cursor": "pointer"
				})
				.bind('selectstart', function () {
					return false;
				})
				.click(function (e) {
					e.preventDefault();

					$(this).text(randString(options.length));

				});

			options.createComplete($input, $captcha);

			var $form = $input.closest("form");

			$form.submit(function (e) {
				if ($input.val() != $captcha.text()) {
					if (options.validateCaptcha) {
						e.preventDefault();
						options.error($input[0]);
					} else {
						$input.addClass("invalidCaptcha");
					}
				} else {
					if (options.validateCaptcha) {
						options.success($input[0]);
					} else {
						$input.removeClass("invalidCaptcha");
					}
				}

			});

		};

		var createCaptchaForForm = function (form) {
			var $form = $(form);
			var $input = $("<INPUT type='TEXT' />").prependTo($form);

			createCaptchaForInput($input[0]);

		};

		return this.each(function (index) {
			if (this.tagName.toUpperCase() == "INPUT") {
				createCaptchaForInput(this);
			} else if (this.tagName.toUpperCase() == "FORM") {
				createCaptchaForForm(this);
			}

		});

	};

	$.fn.captcha.defaults =
		{
			length: 6,
			validateCaptcha: true,
			errorMessage: "Valores não conferem",
			error: function (element) { },
			createComplete: function (inputElem, captchaElem) { },
			success: function (element) { }
		};

})(jQuery);