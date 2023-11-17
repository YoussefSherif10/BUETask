import * as yup from "yup";
import { isValidPhoneNumber } from "react-phone-number-input/mobile";

export const validation =  () => yup.object().shape({
  name: yup
    .string()
    .max(100, "can't be longer than 100 characters")
    .required("Name is required"),
  email: yup
    .string()
    .email("Invalid email")
    .max(100, "can't be longer than 100 characters")
    .required("Email is required"),
  phone: yup.string().required("Password is required").test('invalid', 'Invalid phone number', value => {
    return isValidPhoneNumber(value);
  }),
  age: yup
    .number()
    .max(60, "must be between 1 and 60")
    .min(1, "must be between 1 and 60")
    .required("Age is required"),
});
