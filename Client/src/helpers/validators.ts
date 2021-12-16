export function isEmail(value: string): boolean | string {
  return (
    /^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i.test(value) ||
    "Invalid email address"
  );
}

export function isValidPassword(value: string): boolean | string {
  return (
    (value.length >= 6 && value.length < 30) ||
    "Password must be between 6 and 30 characters"
  );
}

export function isMaxLengthValid(length: number) {
  return (value: string) => value.length <= length || `Max length is ${length}`;
}

export function isMinLengthValid(length: number) {
  return (value: string) => value.length >= length || `Min length is ${length}`;
}

export function dateRequired(value: string) {
  return !!value || "Date is required";
}

export function isDateValid(value: string) {
  return new Date(value) < new Date() || "Date cannot be in future";
}

const validators = {
  isEmail,
  isValidPassword,
  isMaxLengthValid,
  isMinLengthValid,
  dateRequired,
  isDateValid,
};

export default validators;
