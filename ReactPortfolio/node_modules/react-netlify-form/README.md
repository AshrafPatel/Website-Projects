# react-netlify-form

A React component to make using Netlify & React forms easier.

## Installation

With npm:

```bash
npm install --save react-netlify-form
```

With Yarn:

```bash
yarn add react-netlify-form
```

## Usage

```jsx
import NetlifyForm from 'react-netlify-form'

<NetlifyForm name='Contact Form'>
  {({ loading, error, success }) => (
    <div>
      {loading &&
        <div>Loading...</div>
      }
      {error &&
        <div>Your information was not sent. Please try again later.</div>
      }
      {success &&
        <div>Thank you for contacting us!</div>
      }
      {!loading && !success &&
        <div>
          <input type='text' name='Name' required />
          <textarea name='Message' required />
          <button>Submit</button>
        </div>
      }
    </div>
  )}
</NetlifyForm>
```

**Note:** In order for Netlify to find your forms, [they must be server-side rendered](https://www.netlify.com/docs/form-handling/) somewhere. If you use react-netlify-form on the client side accidently the form will still render but it won't work. You can work around this by adding a hidden form that renders server-side elsewhere.

## Usage with reCAPTCHA

This module uses [react-google-recaptcha](https://github.com/dozoisch/react-google-recaptcha) under the hood, so you can pass all the same options through the `recaptcha` prop.

You will also need to follow Netlify's instructions on [bringing your own reCAPTCHA to Netlify Forms](https://www.netlify.com/blog/2018/05/23/bring-your-own-recaptcha-to-netlify-forms/), which basically just involves setting some environment variables.

### reCAPTCHA v2

```jsx
<NetlifyForm
  name='Form With Recaptcha'
  recaptcha={{
    sitekey: 'my_recaptcha_site_key',
    size: 'normal'
  }}
>
  {({ loading, error, recaptchaError, success, recaptcha }) => (
    <div>
      {loading &&
        <div>Loading...</div>
      }
      {error &&
        <div>Your information was not sent. Please try again later.</div>
      }
      {recaptchaError &&
        <div>Recaptcha did not match. Please make sure the box is checked.</div>
      }
      {success &&
        <div>Thank you for contacting us!</div>
      }
      {!loading && !success &&
        <div>
          <input type='text' name='Name' required />
          <textarea name='Message' required />
          {recaptcha}
          <button>Submit</button>
        </div>
      }
    </div>
  )}
</NetlifyForm>
```

### Invisible reCAPTCHA

```jsx
<NetlifyForm
  name='Form With Invisible Recaptcha'
  recaptcha={{
    sitekey: 'my_recaptcha_site_key',
    size: 'invisible'
  }}
>
  {({ loading, error, recaptchaError, success, recaptcha }) => (
    <div>
      {loading &&
        <div>Loading...</div>
      }
      {error &&
        <div>Your information was not sent. Please try again later.</div>
      }
      {recaptchaError &&
        <div>Recaptcha did not match. Please make sure the box is checked.</div>
      }
      {success &&
        <div>Thank you for contacting us!</div>
      }
      {!loading && !success &&
        <div>
          <input type='text' name='Name' required />
          <textarea name='Message' required />
          <button>Submit</button>
        </div>
      }
      {/* Invisible reCAPTCHA must be kept outside of conditionals */}
      {recaptcha}
    </div>
  )}
</NetlifyForm>
```

## Optional properties

- `name`: The form name that will show up in your Netlify dashboard. Default: `"Form"`
- `canSubmit`: Set this to false to disable the form. Useful for things like live validation. Default: `true`
- `recaptcha`: Your recaptcha options object for [react-google-recaptcha](https://github.com/dozoisch/react-google-recaptcha)
- `onSubmit`: A function that runs as soon as the form is submit.
- `onSuccess`: A function that runs as soon as the data has successfully posted to Netlify.
- `onError`: A function that runs if there are errors posting to Netlify.
- `validate`: A promise function that runs before form submission. Return `true` to prevent the form from submitting.
- `honeypotName`: The name of the honeypot field. Default: `"__bf"`
