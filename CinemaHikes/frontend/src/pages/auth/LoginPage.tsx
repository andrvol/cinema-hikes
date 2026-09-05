import { useState } from "react";
import {
  Form,
  Input,
  Button,
  Typography,
  message,
  Row,
  Col,
  Divider,
} from "antd";
import {
  UserOutlined,
  LockOutlined,
  GoogleOutlined,
  GithubOutlined,
  FacebookFilled,
} from "@ant-design/icons";
import { useNavigate } from "react-router-dom";

const { Title, Text } = Typography;
export const LoginPage = () => {
  const handleSocialLogin = (provider: string) => {
    message.success(`Logging in with ${provider}...`);
    navigate("/");
  };
  const socialBtnStyle = {
    backgroundColor: "transparent",
    borderColor: "#333",
    color: "#fff",
    height: "40px",
    display: "flex",
    alignItems: "center",
    justifyContent: "center",
  };
  const [loading, setLoading] = useState(false);
  const navigate = useNavigate();
  const onFinish = (values: { username: string; password: string }) => {
    setLoading(true);
    setTimeout(() => {
      setLoading(false);
      message.success(`Welcome, ${values.username}`);
      navigate("/");
    }, 1500);
  };
  return (
    <Row style={{ minHeight: "100vh", backgroundColor: "#141414" }}>
      <Col
        xs={0}
        md={12}
        lg={14}
        style={{
          backgroundColor: "#1f1f1f",
          display: "flex",
          justifyContent: "center",
          alignItems: "center",
          padding: "40px",
          borderRight: "1px solid #333",
        }}
      >
        <div style={{ textAlign: "center", maxWidth: "80%" }}>
          <img
            src="https://i.imgur.com/N1P4OeD.jpeg"
            alt="pirattv"
            style={{
              maxWidth: "100%",
              borderRadius: "24px",
              boxShadow: "0 20px 40px rgba(0,0,0,0.5)",
            }}
          />
        </div>
      </Col>
      <Col
        xs={24}
        md={12}
        lg={10}
        style={{
          display: "flex",
          flexDirection: "column",
          justifyContent: "center",
          padding: "0 8%",
        }}
      >
        <div style={{ maxWidth: "380px", width: "100%", margin: "0 auto" }}>
          <div
            onClick={() => navigate("/")}
            style={{
              color: "#E50914",
              fontSize: "28px",
              fontWeight: 900,
              cursor: "pointer",
              marginBottom: "32px",
            }}
          >
            PIRAT.tv
          </div>
          <Title style={{ color: "#fff", marginBottom: "8px", margin: 0 }}>
            Welcome Back!
          </Title>
          <Text
            style={{
              color: "#888",
              display: "block",
              marginBottom: "32px",
              fontSize: "16px",
            }}
          >
            Enter your credentials to access the treasure.
          </Text>
          <Form
            name="login_form"
            layout="vertical"
            onFinish={onFinish}
            size="large"
          >
            <Form.Item
              name="username"
              rules={[
                { required: true, message: "Please enter your pirate alias!" },
              ]}
            >
              <Input
                prefix={<UserOutlined style={{ color: "#555" }} />}
                placeholder="Username or Email"
                style={{
                  backgroundColor: "#1f1f1f",
                  borderColor: "#333",
                  color: "#fff",
                  borderRadius: "8px",
                }}
              />
            </Form.Item>

            <Form.Item
              name="password"
              rules={[
                { required: true, message: "Password is required to board!" },
              ]}
            >
              <Input.Password
                prefix={<LockOutlined style={{ color: "#555" }} />}
                placeholder="Password"
                style={{
                  backgroundColor: "#1f1f1f",
                  borderColor: "#333",
                  color: "#fff",
                  borderRadius: "8px",
                }}
              />
            </Form.Item>

            <Form.Item>
              <Button
                type="primary"
                htmlType="submit"
                loading={loading}
                block
                style={{
                  backgroundColor: "#E50914",
                  borderColor: "#E50914",
                  height: "48px",
                  fontSize: "16px",
                  fontWeight: "bold",
                  borderRadius: "8px",
                }}
              >
                Set Sail
              </Button>
            </Form.Item>
            <Divider
              plain
              style={{
                borderColor: "#333",
                color: "#666",
                fontSize: "14px",
                margin: "16px 0",
              }}
            >
              or continue with
            </Divider>

            <Row gutter={12}>
              <Col span={8}>
                <Button
                  block
                  icon={<GoogleOutlined style={{ color: "#DB4437" }} />}
                  style={socialBtnStyle}
                  onClick={() => handleSocialLogin("Google")}
                >
                  Google
                </Button>
              </Col>
              <Col span={8}>
                <Button
                  block
                  icon={<GithubOutlined />}
                  style={socialBtnStyle}
                  onClick={() => handleSocialLogin("GitHub")}
                >
                  GitHub
                </Button>
              </Col>
              <Col span={8}>
                <Button
                  block
                  icon={<FacebookFilled style={{ color: "#4267B2" }} />}
                  style={socialBtnStyle}
                  onClick={() => handleSocialLogin("Facebook")}
                >
                  Facebook
                </Button>
              </Col>
            </Row>

            <div style={{ textAlign: "center", marginTop: "24px" }}>
              <Text style={{ color: "#888" }}>Don't have a treasure map? </Text>
              <Button
                type="link"
                onClick={() => navigate("/register")}
                style={{ color: "#E50914", padding: 0 }}
              >
                Register
              </Button>
            </div>
          </Form>
        </div>
      </Col>
    </Row>
  );
};
