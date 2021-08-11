using System;

namespace car_rental_client
{
    public enum RESPONSE_RESULT { LOGIN_SUCCESS, ACCOUNT_NOT_FOUND, PASSWORD_WRONG, OTHER_WRONG = 255 }

    public class CarRentalLogin
    {
        public static RESPONSE_RESULT login(LOGIN_TYPE type, string account = "", string password = "")
        {
            // 登录报文格式：
            // ACCOUNT TYPE \[account\] \[password\] \r\n
            string msg = "ACCOUNT ";
            if (type == LOGIN_TYPE.VISITOR)
            {
                CarRentalClient.send(msg + "VISITOR \r\n");
            }
            else if (type == LOGIN_TYPE.USER)
            {
                CarRentalClient.send(msg + "USER " + account + " " + password + " \r\n");
            }
            else if (type == LOGIN_TYPE.ADMINISTRATOR)
            {
                CarRentalClient.send(msg + "ADMINISTRATOR " + account + " " + password + " \r\n");
            }

            int is_closed = 0;
            string result = CarRentalClient.receive(ref is_closed);
            if (result == null || is_closed == 1)
                return RESPONSE_RESULT.OTHER_WRONG;

            string[] result_arrays = result.Split(' ');
            if (result_arrays[0].Equals("LOGIN_SUCCESS"))
                return RESPONSE_RESULT.LOGIN_SUCCESS;
            else if (result_arrays[0].Equals("ACCOUNT_NOT_FOUND"))
                return RESPONSE_RESULT.ACCOUNT_NOT_FOUND;
            else if (result_arrays[0].Equals("PASSWORD_WRONG"))
                return RESPONSE_RESULT.PASSWORD_WRONG;
            else
                return RESPONSE_RESULT.OTHER_WRONG;
        }
    }
}